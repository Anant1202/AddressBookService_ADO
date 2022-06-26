using ADO_AddressBookServiceDB;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodInsertIntoTable()
        {
            int expected = 1;
            AddressBookTable addressBook = new AddressBookTable();
            addressBook.FirstName = "Karan";
            addressBook.LastName = "Sharma";
            addressBook.Address = "Sector 7";
            addressBook.City = "Mumbai";
            addressBook.State = "Maharashtra";
            addressBook.zip = 400037;
            addressBook.PhoneNumber = 9842691250;
            addressBook.Email = "karans@gmail.com";
            addressBook.AddressBookName = "FriendName";
            addressBook.Type = "Friends";
            AddressBook obj1 = new AddressBook();
            int actual = obj1.InsertIntoTable(addressBook);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenUpdateQuery_ReturnOne()
        {
            int expected = 1;
            AddressBook obj1 = new AddressBook();
            int actual = obj1.UpdateExistingContactBasedonName();
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void GivenDeleteQuery_ReturnOne()
        {
            int expected = 1;
            AddressBook obj1 = new AddressBook();
            int actual = obj1.DeleteContactBasedonName();
            Assert.AreEqual(expected, actual);
        }
    }
}

