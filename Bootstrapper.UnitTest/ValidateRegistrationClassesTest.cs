using Autofac;
using Bootstrapper.Contract.Attributes;
using Bootstrapper.Contract.Exceptions;
using Bootstrapper.Contract.Interfaces;
using Bootstrapper.Mapping;
using Bootstrapper.UnitTest.DataModels;

namespace Bootstrapper.UnitTest;

public class ValidateRegistrationClassesTest
{
    private IContainer _container;

    [SetUp]
    public void Setup()
    {
        _container = new BootstrapperMapping().Build();
    }

    [Test]
    public void ValidateClassWithRegisterAttributTest()
    {
        List<Module> mappingList = new()
        {
            new ValidationTestWithRegisterAttribute_DataModel()
        };

        var validateClasses = _container.Resolve<IValidateRegistrationClasses>().ValidateClasses<Module, BuildRegisterAttribute>(mappingList);

        Assert.That(validateClasses.Count, Is.EqualTo(mappingList.Count));
    }

    [Test]
    public void ValidateClassWithoutRegisterAttributTest()
    {
        List<Module> mappingList = new()
        {
            new ValidationTestWithoutRegisterAttribute_DataModel()
        };

        Assert.Throws<AttributeNotFoundException>(() =>
        {
            _container.Resolve<IValidateRegistrationClasses>().ValidateClasses<Module, BuildRegisterAttribute>(mappingList);
        });
    }

    [Test]
    public void ValidateClassWithDifferentAttributsTest()
    {
        List<Module> mappingList = new()
        {
            new ValidationTestWithRegisterAttribute_DataModel(),
            new ValidationTestWithTestingAttribute_DataModel()
        };

        var validateClasses = _container.Resolve<IValidateRegistrationClasses>().ValidateClasses<Module, BuildRegisterAttribute>(mappingList);

        Assert.That(validateClasses.Count, Is.EqualTo(1));
    }


    [TearDown]
    public void Teardown()
    {
        _container.Dispose();
    }
}