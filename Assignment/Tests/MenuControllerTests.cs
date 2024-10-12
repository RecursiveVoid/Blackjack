using NUnit.Framework;
using NUnit.Compatibility;
using Moq;
using Assignment.EventArguments;
using Assignment.Models;
using Assignment.Types;
using Assignment.Views;
using System;
using System.Collections.Generic;
using Assignment.Controllers;
using Assignment.Modes;
using NUnit.Framework.Legacy;

namespace Assignment.Tests
{
    [TestFixture]
    public class MenuControllerTests
    {
        private Mock<MenuModel> _mockModel;
        private Mock<MenuView> _mockView;
        private Mock<MenuController> _mockController;

        [SetUp]
        public void SetUp()
        {
            _mockModel = new Mock<MenuModel>();
            _mockView = new Mock<MenuView>(_mockModel.Object);
            _mockController = new Mock<MenuController>(_mockModel.Object, _mockView.Object);
        }

        [Test]
        public void Start_ShouldSetStatusToInit()
        {
            _mockController.Object.Start();
            ClassicAssert.AreEqual(MenuStatus.INIT, _mockModel.Object.Status);
        }
    }
}
