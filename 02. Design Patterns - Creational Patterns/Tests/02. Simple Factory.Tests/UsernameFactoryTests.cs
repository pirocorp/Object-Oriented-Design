namespace Simple_Factory_Tests
{
    using Simple_Factory.UserName;

    public class UsernameFactoryTests
    {
        private readonly UsernameFactory factory;

        public UsernameFactoryTests()
        {
            this.factory = new UsernameFactory();
        }

        [Fact]
        public void ShouldGetFirstNameFirst()
        {
            //arrange
            const string user = "Zdravko Zdravkov";
           
            //act
            var username = this.factory.GetUserName(user);

            //assert
            Assert.Equal("Zdravko", username.FirstName);
            Assert.Equal("Zdravkov", username.LastName);
            Assert.Equal("FirstNameFirst", username.GetType().Name);
        }

        [Fact]
        public void ShouldGetLastNameFirst()
        {
            //arrange
            const string user = "Zdravkov, Zdravko";

            //act
            var username = this.factory.GetUserName(user);

            //assert
            Assert.Equal("Zdravko", username.FirstName);
            Assert.Equal("Zdravkov", username.LastName);
            Assert.Equal("LastNameFirst", username.GetType().Name);
        }
    }
}