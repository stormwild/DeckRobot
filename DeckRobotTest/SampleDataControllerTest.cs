using System;
using System.Linq;
using Xunit;
using DeckRobotWeb.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DeckRobotTest
{
    public class SampleDataControllerTest
    {
        [Fact]
        public void WeatherForecasts_Returns_List_Of_WeatherForecast()
        {
            // Arrange
            var controller = new SampleDataController();

            // Act
            var result = controller.WeatherForecasts(0) as IEnumerable<WeatherForecast>;

            // Assert
            Assert.Equal(5, result.Count());
        }
    }
}
