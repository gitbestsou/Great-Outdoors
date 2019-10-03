using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capgemini.GreatOutdoors.BusinessLayer;
using Capgemini.GreatOutdoors.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capgemini.GreatOutdoors.UnitTests
{
    [TestClass]
    public class AddSalesPersonBLTest
    {
        /// <summary>
        /// Add SalesPerson to the Collection if it is valid.
        /// </summary>
        [TestMethod]
        public async Task AddValidSalesPerson()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Scott", SalesPersonMobile = "9876543210", Password = "Scott123#", Email = "scott@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Name can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonNameCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = null, SalesPersonMobile = "9988776655", Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Mobile can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonMobileCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Smith", SalesPersonMobile = null, Password = "Smith123#", Email = "smith@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Password can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonPasswordCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Allen", SalesPersonMobile = "9877766554", Password = null, Email = "allen@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPerson Email can't be null
        /// </summary>
        [TestMethod]
        public async Task SalesPersonEmailCanNotBeNull()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9876543210", Password = "John123#", Email = null };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPersonName should contain at least two characters
        /// </summary>
        [TestMethod]
        public async Task SalesPersonNameShouldContainAtLeastTwoCharacters()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "J", SalesPersonMobile = "9877897890", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// SalesPersonMobile should be a valid mobile number
        /// </summary>
        [TestMethod]
        public async Task SalesPersonMobileRegExp()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9877", Password = "John123#", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Password should be a valid password as per regular expression
        /// </summary>
        [TestMethod]
        public async Task SalesPersonPasswordRegExp()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9877897890", Password = "John", Email = "john@gmail.com" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }

        /// <summary>
        /// Email should be a valid email as per regular expression
        /// </summary>
        [TestMethod]
        public async Task SalesPersonEmailRegExp()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9877897890", Password = "John123#", Email = "john" };
            bool isAdded = false;
            string errorMessage = null;

            //Act
            try
            {
                isAdded = await salesPersonBL.AddSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isAdded = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isAdded, errorMessage);
            }
        }
    }


    [TestClass]
    public class GetSalesPersonBySalesPersonIDBLTest
{
    /// <summary>
    /// Get SalesPerson if given ID is valid
    /// </summary>
    [TestMethod]
    public async Task ValidSalesPersonID()
    {
        //Arrange
        SalesPersonBL salesPersonBL = new SalesPersonBL();
        SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Scott", SalesPersonMobile = "9876543210", Password = "Scott123#", Email = "scott@gmail.com" };
        await salesPersonBL.AddSalesPersonBL(salesPerson);
        bool isValid = false;
        string errorMessage = null;

        //Act
        try
        {
            if (salesPerson.Equals(await salesPersonBL.GetSalesPersonBySalesPersonIDBL(salesPerson.SalesPersonID)))
                isValid = true;
        }
        catch (Exception ex)
        {
            isValid = false;
            errorMessage = ex.Message;
        }
        finally
        {
            //Assert
            Assert.IsTrue(isValid, errorMessage);
        }
    }

    /// <summary>
    /// Should raise an error if invalid SalesPerson ID is given
    /// </summary>
    [TestMethod]
    public async Task InvalidSalesPersonID()
    {
        //Arrange
        SalesPersonBL salesPersonBL = new SalesPersonBL();
        Guid invalidID = new Guid();
        bool isValid = true;
        string errorMessage = null;

        //Act
        try
        { SalesPerson salesPerson = new SalesPerson();
            if ((salesPerson = (await salesPersonBL.GetSalesPersonBySalesPersonIDBL(invalidID))) == null )
                isValid = false;
        }
        catch (Exception ex)
        {
            isValid = true;
            errorMessage = ex.Message;
        }
        finally
        {
            //Assert
            Assert.IsFalse(isValid, errorMessage);
        }
    }

}

    [TestClass]
    public class GetSalesPersonByNameBLTest
    {
        /// <summary>
        /// Get SalesPerson if given name is valid
        /// </summary>
        [TestMethod]
        public async Task ValidSalesPersonName()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Scott", SalesPersonMobile = "9876543210", Password = "Scott123#", Email = "scott@gmail.com" };
            await salesPersonBL.AddSalesPersonBL(salesPerson);
            bool isValid = false;
            string errorMessage = null;

            //Act
            try
            {
                List<SalesPerson> salesPeople = new List<SalesPerson>();
                if ((salesPeople = (await salesPersonBL.GetSalesPersonsByNameBL(salesPerson.SalesPersonName))) != null)
                    isValid = true;
            }
            catch (Exception ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isValid, errorMessage);
            }
        }

        /// <summary>
        /// Should raise an error if invalid SalesPerson Name is given
        /// </summary>
        [TestMethod]
        public async Task InvalidSalesPersonName()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            string invalidName= "io";
            bool isValid = true;
            string errorMessage = null;

            //Act
            try
            {
                List<SalesPerson> salesPeople = new List<SalesPerson>();
                if ((salesPeople = (await salesPersonBL.GetSalesPersonsByNameBL(invalidName))) == null)
                    isValid = false;
            }
            catch (Exception ex)
            {
                isValid = true;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }


    /// <summary>
    /// Should raise an error if SalesPerson Name is null
    /// </summary>
    [TestMethod]
    public async Task SalesPersonNameCannotBeNull()
    {
        //Arrange
        SalesPersonBL salesPersonBL = new SalesPersonBL();
        string invalidName = null;
        bool isValid = true;
        string errorMessage = null;

        //Act
        try
        {
            List<SalesPerson> salesPeople = new List<SalesPerson>();
            if ((salesPeople = (await salesPersonBL.GetSalesPersonsByNameBL(invalidName))) == null)
                isValid = false;
        }
        catch (Exception ex)
        {
            isValid = true;
            errorMessage = ex.Message;
        }
        finally
        {
            //Assert
            Assert.IsFalse(isValid, errorMessage);
        }
    }

}

    [TestClass]
    public class GetSalesPersonByEmailBLTest
    {
        /// <summary>
        /// Get SalesPerson if given email is valid
        /// </summary>
        [TestMethod]
        public async Task ValidSalesPersonEmail()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Scott", SalesPersonMobile = "9876543210", Password = "Scott123#", Email = "scott@gmail.com" };
            await salesPersonBL.AddSalesPersonBL(salesPerson);
            bool isValid = false;
            string errorMessage = null;

            //Act
            try
            {
                if (salesPerson.Equals((await salesPersonBL.GetSalesPersonByEmailBL(salesPerson.Email))))
                    isValid = true;
            }
            catch (Exception ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isValid, errorMessage);
            }
        }

        /// <summary>
        /// Should raise an error if given email doesn't exist
        /// </summary>
        [TestMethod]
        public async Task SalesPersonEmailDoesNotExist()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            string invalidEmail = "io@abc.com";
            bool isValid = true;
            string errorMessage = null;

            //Act
            try
            {
                SalesPerson salesPerson = new SalesPerson();
                if ((salesPerson = (await salesPersonBL.GetSalesPersonByEmailBL(invalidEmail))) == null)
                    isValid = false;
            }
            catch (Exception ex)
            {
                isValid = true;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }


        /// <summary>
        /// Should raise an error if SalesPerson Email is in invalid format
        /// </summary>
        [TestMethod]
        public async Task SalesPersonEmailRegExp()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            string invalidEmail = "abc";
            bool isValid = true;
            string errorMessage = null;

            //Act
            try
            {
                SalesPerson salesPerson = new SalesPerson();
                if ((salesPerson = (await salesPersonBL.GetSalesPersonByEmailBL(invalidEmail))) == null)
                    isValid = false;
            }
            catch (Exception ex)
            {
                isValid = true;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }

    }

    [TestClass]
    public class GetSalesPersonByEmailAndPasswordBLTest
    {
        /// <summary>
        /// Get SalesPerson if given email and password are valid
        /// </summary>
        [TestMethod]
        public async Task ValidSalesPersonEmailAndPassword()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Scott", SalesPersonMobile = "9876543210", Password = "Scott123", Email = "scott@gmail.com" };
            await salesPersonBL.AddSalesPersonBL(salesPerson);
            bool isValid = false;
            string errorMessage = null;

            //Act
            try
            {
                if (salesPerson.Equals((await salesPersonBL.GetSalesPersonByEmailAndPasswordBL(salesPerson.Email,salesPerson.Password))))
                    isValid = true;
            }
            catch (Exception ex)
            {
                isValid = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isValid, errorMessage);
            }
        }

        /// <summary>
        /// Should raise an error if given email is correct but password is incorrect
        /// </summary>
        [TestMethod]
        public async Task SalesPersonEmailCorrectPasswordIncorrect()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            string invalidPassword = "abc2com";
            bool isValid = true;
            string errorMessage = null;

            //Act
            try
            {
                SalesPerson salesPerson = new SalesPerson();
                if ((salesPerson = (await salesPersonBL.GetSalesPersonByEmailAndPasswordBL(salesPerson.Email,invalidPassword))) == null)
                    isValid = false;
            }
            catch (Exception ex)
            {
                isValid = true;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }


        /// <summary>
        /// Should raise an error if SalesPerson's email is incorrect and password is correct
        /// </summary>
        [TestMethod]
        public async Task SalesPersonEmailIncorrectPasswordCorrect()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Scott", SalesPersonMobile = "9876543210", Password = "Scott123#", Email = "scott@gmail.com" };
            await salesPersonBL.AddSalesPersonBL(salesPerson);
            string invalidEmail = "abc";
            bool isValid = true;
            string errorMessage = null;

            //Act
            try
            {
                if ((salesPerson = (await salesPersonBL.GetSalesPersonByEmailAndPasswordBL(invalidEmail,salesPerson.Password))) == null)
                    isValid = false;
            }
            catch (Exception ex)
            {
                isValid = true;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }

        /// <summary>
        /// Should raise an error if SalesPerson's email is incorrect and password is correct
        /// </summary>
        [TestMethod]
        public async Task SalesPersonEmailIncorrectPasswordIncorrect()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            string invalidEmail = "abc";
            string invalidPassword = "8888";
            bool isValid = true;
            string errorMessage = null;

            //Act
            try
            {
                SalesPerson salesPerson = new SalesPerson();
                if (( salesPerson = (await salesPersonBL.GetSalesPersonByEmailAndPasswordBL(invalidEmail, invalidPassword))) == null)
                    isValid = false;
            }
            catch (Exception ex)
            {
                isValid = true;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isValid, errorMessage);
            }
        }

    }

    [TestClass]
    public class UpdateSalesPersonBLTest
    {
        /// <summary>
        /// Update SalesPerson's details if given name,email and mobile are valid
        /// </summary>
        [TestMethod]
        public async Task ValidSalesPersonDetails()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9876543210", Password = "Scott123", Email = "john@gmail.com" };
            await salesPersonBL.AddSalesPersonBL(salesPerson);

            salesPerson.SalesPersonName = "John";
            salesPerson.Email = "john@greatoutdoors.com";
            salesPerson.SalesPersonMobile = "8897476406";

            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await salesPersonBL.UpdateSalesPersonBL(salesPerson);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isUpdated, errorMessage);
            }
        }

        

    }

    [TestClass]
    public class UpdateSalesPersonPasswordBLTest
    {
        /// <summary>
        /// Update SalesPerson's password if given password is valid
        /// </summary>
        [TestMethod]
        public async Task ValidSalesPersonPassword()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9876543210", Password = "Scott123", Email = "john@gmail.com" };
            await salesPersonBL.AddSalesPersonBL(salesPerson);

            salesPerson.Password = "John123";

            bool isUpdated = false;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await salesPersonBL.UpdateSalesPersonPasswordBL(salesPerson);
            }
            catch (Exception ex)
            {
                isUpdated = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isUpdated, errorMessage);
            }
        }

        /// <summary>
        ///SAles person password should follow given format
        /// </summary>
        [TestMethod]
        public async Task InvalidSalesPersonPassword()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "John", SalesPersonMobile = "9876543210", Password = "Scott123", Email = "john@gmail.com" };
            await salesPersonBL.AddSalesPersonBL(salesPerson);

            salesPerson.Password = "John";

            bool isUpdated = true;
            string errorMessage = null;

            //Act
            try
            {
                isUpdated = await salesPersonBL.UpdateSalesPersonPasswordBL(salesPerson);
            }
            catch (Exception ex)
            {
                isUpdated = true;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isUpdated, errorMessage);
            }
        }



    }

    [TestClass]
    public class DeleteSalesPersonBLTest
    {
        /// <summary>
        /// Delete SalesPerson if given ID is valid
        /// </summary>
        [TestMethod]
        public async Task ValidSalesPersonID()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            SalesPerson salesPerson = new SalesPerson() { SalesPersonName = "Scott", SalesPersonMobile = "9876543210", Password = "Scott123#", Email = "scott@gmail.com" };
            await salesPersonBL.AddSalesPersonBL(salesPerson);
            bool isDeleted = false;
            string errorMessage = null;

            //Act
            try
            {
                    isDeleted = await salesPersonBL.DeleteSalesPersonBL(salesPerson.SalesPersonID);
            }
            catch (Exception ex)
            {
                isDeleted = false;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsTrue(isDeleted, errorMessage);
            }
        }

        /// <summary>
        /// Should raise an error if invalid SalesPerson ID is given
        /// </summary>
        [TestMethod]
        public async Task InvalidSalesPersonID()
        {
            //Arrange
            SalesPersonBL salesPersonBL = new SalesPersonBL();
            Guid invalidID = new Guid();
            bool isDeleted = true;
            string errorMessage = null;

            //Act
            try
            {
                isDeleted = await salesPersonBL.DeleteSalesPersonBL(invalidID);
            }
            catch (Exception ex)
            {
                isDeleted = true;
                errorMessage = ex.Message;
            }
            finally
            {
                //Assert
                Assert.IsFalse(isDeleted, errorMessage);
            }
        }

    }
}

