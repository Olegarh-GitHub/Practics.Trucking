using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Practics.Trucking.Application.AutoMapping;
using Practics.Trucking.Application.Inputs.Product;
using Practics.Trucking.Application.Inputs.Specification;
using Practics.Trucking.Application.Inputs.User;
using Practics.Trucking.Application.Services;
using Practics.Trucking.Domain.Interfaces;
using Practics.Trucking.Domain.Models;
using Practics.Trucking.Infrastructure.AutoMapping;
using Practics.Trucking.Infrastructure.Contexts;
using Practics.Trucking.Infrastructure.Repositories;

namespace Practics.Trucking.Tests
{
    public class Tests
    {
        private ApplicationContext _context;
        private IAsyncRepository<User> _userRepo;
        private IAsyncRepository<UserInfo> _userInfoRepo;
        private IAsyncRepository<Order> _userOrderRepo;
        private IAsyncRepository<Product> _prodrepo;
        private UserService _userService;
        private ProductService _productSer;
        
        [SetUp]
        public void Setup()
        {
            DbContextOptions<ApplicationContext> options = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Trucking_SSLE;").Options;

            _context = new ApplicationContext(options);
            _userRepo = new EntityFrameworkAsyncRepository<User>(_context,
                new Mapper(new MapperConfiguration(x => x.AddProfile(typeof(EntityUpdateMappingProfile)))));

            _userInfoRepo = new EntityFrameworkAsyncRepository<UserInfo>(_context,
                new Mapper(new MapperConfiguration(x => x.AddProfile(typeof(EntityUpdateMappingProfile)))));
            
            _userOrderRepo = new EntityFrameworkAsyncRepository<Order>(_context,
                new Mapper(new MapperConfiguration(x => x.AddProfile(typeof(EntityUpdateMappingProfile)))));
            
            _prodrepo = new EntityFrameworkAsyncRepository<Product>(_context,
                new Mapper(new MapperConfiguration(x => x.AddProfile(typeof(EntityUpdateMappingProfile)))));

            _userService = new UserService(_userRepo, _userInfoRepo,
                new Mapper(new MapperConfiguration(x => x.AddProfile(typeof(InputMappingProfile)))), _userOrderRepo);

            _productSer = new ProductService(_prodrepo,
                new Mapper(new MapperConfiguration(x => x.AddProfile(typeof(InputMappingProfile)))));
        }

        [Test]
        public void TryLoginTest()
        {
            var userTryLogin = new UserTryLoginInput
            (
                "abramov",
                "12345678"
            );
            
            Assert.AreEqual(true, _userService.TryLogin(userTryLogin));
        }
        
        [Test]
        public void TryLoginTest_2()
        {
            var userTryLogin = new UserTryLoginInput
            (
                "abramov",
                "1234567"
            );
            
            Assert.AreEqual(false, _userService.TryLogin(userTryLogin));
        }
        
        [Test]
        public void TryLoginTest_3()
        {
            var userTryLogin = new UserTryLoginInput
            (
                "sharipov.b",
                "12345"
            );
            
            Assert.AreEqual(true, _userService.TryLogin(userTryLogin));
        }
        
        [Test]
        public void TryLoginTest_4()
        {
            var userTryLogin = new UserTryLoginInput
            (
                "",
                ""
            );
            
            Assert.AreEqual(false, _userService.TryLogin(userTryLogin));
        }
        
        [Test]
        public async Task Create_User()
        {
            var user = new UserRegisterInput
            (
                "oabramov",
                "oasda"
            );

            Assert.AreEqual(null, await _userService.RegisterUser(user));
        }
        
        [Test]
        public async Task Create_User_0()
        {
            var user = new UserRegisterInput
            (
                "abram",
                "oasda",
                "Abramov",
                "Oleg",
                "Nikoliavch"
            );

            var userfrominput = await _userService.RegisterUser(user);
            
            Assert.NotNull(userfrominput);

            await _userRepo.DeleteAsync(userfrominput);
        }
        
        [Test]
        public async Task Create_User_1()
        {
            var user = new UserRegisterInput
            (
                "sharipov",
                "oasda",
                "Abramov",
                "Oleg",
                "Nikoliavch"
            );

            var userfrominput = await _userService.RegisterUser(user);
            
            Assert.Null(userfrominput);
        }

        [Test]
        public async Task Create_Product()
        {
            var product = new ProductRegisterInput
                ("Audi 100 C3", "Automobile", 100m, null, new List<SpecificationRegisterInput>() {new () {Name = "Quattro", Value = "true"}});

            var productfrominput = await _productSer.RegisterProduct(product);
            
            Assert.NotNull(productfrominput);
        }
        
        [Test]
        public async Task Create_Product_0()
        {
            var product = new ProductRegisterInput
                ("Audi 100 C3 typ 44Q", "Automobile Ingolstadt", 10500m, null, new List<SpecificationRegisterInput>() {new () {Name = "Quattro", Value = "true"}, new () {Name = "Turbo", Value = "true"}});

            var productfrominput = await _productSer.RegisterProduct(product);
            
            Assert.NotNull(productfrominput);
        }

        [Test]
        public async Task Create_Product_1()
        {
            ProductRegisterInput product = null;

            Assert.Catch<AggregateException>( delegate
            {
                 var a= _productSer.RegisterProduct(new ProductRegisterInput()).Result;
            });
        }
        
        [Test]
        public async Task Create_Product_2()
        {
            ProductRegisterInput product = null;

            Assert.Catch<AggregateException>( delegate
            {
                var a= _productSer.RegisterProduct(null).Result;
            });
        }
    }
}