namespace Simple_Factory_Tests
{
    using Simple_Factory.UserName;

    public class FirstNameFirstTest
    {
        [Fact]
        public void ShouldSplitStringOnSpace()
        {
            const string theName = "Zdravko Zdravkov"; 
            var splitName = new FirstNameFirst(theName);
            
            Assert.Equal("Zdravko", splitName.FirstName);
            Assert.Equal("Zdravkov", splitName.LastName);
            
        }

        [Fact]
        public void FailSplitOnStringOnComma()
        {
            const string theName = "Zdravko,Zdravkov"; 
            var splitName = new FirstNameFirst(theName);
             
            Assert.Equal(string.Empty, splitName.FirstName);
            Assert.Equal(string.Empty, splitName.LastName);
        }
    }
}
