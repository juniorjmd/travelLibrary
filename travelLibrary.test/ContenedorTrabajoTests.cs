using NUnit.Framework;
using travelLibrary.AccesoDatos.Data;
using travelLibrary.AccesoDatos.Data.Repository;

namespace travelLibrary.Tests.AccesoDatos.Data.Repository
{
    [TestFixture]
    public class ContenedorTrabajoTests
    {
        private MyDBContext _dbContext;
        private ContenedorTrabajo _contenedorTrabajo;

        [SetUp]
       

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
            _contenedorTrabajo.Dispose();
        }

        [Test]
        public void ContenedorTrabajo_Save_CallsSaveChanges()
        {
            // Arrange

            // Act
            _contenedorTrabajo.Save();

            // Assert
            // Agrega las aserciones necesarias aquí
        }
    }
}
