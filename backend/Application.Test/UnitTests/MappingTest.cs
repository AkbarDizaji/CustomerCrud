using Application.Commons.DTOs;
using Application.Commons.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Application.UnitTests
{
    public class MappingTest
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;
        public MappingTest()
        {
            _configuration = new MapperConfiguration(config =>
                            config.AddProfile<MappingProfile>());
            _mapper = _configuration.CreateMapper();
        }
        [Theory]
        [InlineData(typeof(Person), typeof(PersonDTO))]
        public void Map_From_Source_To_Destination_convert_correct(Type source, Type destination)
        {
            var sourceInstance = GetInstanceOf(source);

            var destinationInstance = _mapper.Map(sourceInstance, source, destination);
            Assert.IsType(destination, destinationInstance);
        }
        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type)!;
            return FormatterServices.GetUninitializedObject(type);
        }
    }
}
