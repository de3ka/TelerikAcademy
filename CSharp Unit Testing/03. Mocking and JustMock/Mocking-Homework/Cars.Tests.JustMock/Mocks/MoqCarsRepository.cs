﻿using Cars.Contracts;
using Cars.Models;
using System.Linq;
using Moq;
using System;

namespace Cars.Tests.JustMock.Mocks
{
    public class MoqCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.All()).Returns(this.FakeCarCollection);

            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>())).Returns(this.FakeCarCollection.ToList());
            mockedCarsRepository.Setup(r => r.Search(It.IsNotNull<string>())).Returns((string search) => this.FakeCarCollection.Where(c => c.Make.ToLower() == search.ToLower() || c.Model.ToLower() == search.ToLower()).ToList());

            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(this.FakeCarCollection.First());
            mockedCarsRepository.Setup(r => r.GetById(It.IsInRange<int>(0, this.FakeCarCollection.Count, Range.Exclusive))).Returns((int id) => this.FakeCarCollection.First(car => car.Id == id));
            mockedCarsRepository.Setup(r => r.GetById(It.IsInRange<int>(0, Int32.MinValue, Range.Inclusive))).Verifiable();

            mockedCarsRepository.Setup(r => r.SortedByMake()).Returns(this.FakeCarCollection.OrderBy(c => c.Make).ToList());
            mockedCarsRepository.Setup(r => r.SortedByYear()).Returns(this.FakeCarCollection.OrderBy(c => c.Year).ToList());
            this.CarsData = mockedCarsRepository.Object;
        }
    }
}