namespace LegacyApp.test;

public class UnitTest1
{

    [Fact]
    public void AddUser_Null_Empty_Name()
    {
        string name = null;
        string surname = "Nowak";
        DateTime date = new DateTime(1900, 12, 12);
        int id = 1;
        string mail = "email@onet.pl";
        var userService = new UserService();

        bool res = userService.AddUser(name, surname, mail, date, id);
        
        Assert.Equal(false, res);
    } 
    
    [Fact]
    public void AddUser_Null_Empty_Surname()
    {
        string name = "Maciej";
        string surname = null;
        DateTime date = new DateTime(1900, 12, 12);
        int id = 1;
        string mail = "email@onet.pl";
        var userService = new UserService();

        bool res = userService.AddUser(name, surname, mail, date, id);
        
        Assert.Equal(false, res);
    } 
    
    
    [Fact]
    public void AddUser_Email_Without_Dot_And_At()
    {
        string name = "Adam";
        string surname = "Nowak";
        DateTime date = new DateTime(1900, 12, 12);
        int id = 1;
        string mail = "email";
        var userService = new UserService();

        bool res = userService.AddUser(name, surname, mail, date, id);
        
        Assert.Equal(false, res);
    }
    
    [Fact]
    public void AddUser_Age_Lower_Than_Required()
    {
        string name = "Adam";
        string surname = "Nowak";
        DateTime date = new DateTime(2012, 12, 12);
        int id = 1;
        string mail = "email@onet.pl";
        var userService = new UserService();

        bool res = userService.AddUser(name, surname, mail, date, id);
        
        Assert.Equal(false, res);
    } 
    
    [Fact]
    public void AddUser_True_With_Very_Important_Client()
    {
        string name = "Adam";
        string surname = "Malewski";
        DateTime date = new DateTime(1983, 11, 12);
        int id = 2;
        string mail = "malewski@gmail.pl";
        var userService = new UserService();

        bool res = userService.AddUser(name, surname, mail, date, id);
        
        Assert.Equal(true, res);
    } 
    
    [Fact]
    public void AddUser_True_With_Important_Client()
    {
        string name = "Adam";
        string surname = "Doe";
        DateTime date = new DateTime(1983, 11, 12);
        int id = 4;
        string mail = "doe@gmail.pl";
        var userService = new UserService();

        bool res = userService.AddUser(name, surname, mail, date, id);
        
        Assert.Equal(true, res);
    } 
    
    [Fact]
    public void AddUser_True_With_Normal_Client()
    {
        string name = "Adam";
        string surname = "Kwiatkowski";
        DateTime date = new DateTime(1983, 11, 12);
        int id = 5;
        string mail = "kwiatkowski@gmail.pl";
        var userService = new UserService();

        bool res = userService.AddUser(name, surname, mail, date, id);
        
        Assert.Equal(true, res);
    } 
    
    [Fact]
    public void AddUser_False_With_Credit_Limit_And_Less_Than_500()
    {
        string name = "Adam";
        string surname = "Kowalski";
        DateTime date = new DateTime(1983, 11, 12);
        int id = 1;
        string mail = "kowalski@wp.pl";
        var userService = new UserService();

        bool res = userService.AddUser(name, surname, mail, date, id);
        
        Assert.Equal(false, res);
    }

    [Fact]
    public void AddUser_User_Does_Not_Exist_Exception()
    {
        string name = "Michal";
        string surname = "Michalski";
        DateTime date = new DateTime(1983, 11, 12);
        int id = 199;
        string mail = "michal@wp.pl";
        var userService = new UserService();

        Assert.Throws<ArgumentException>(() =>
        {
            userService.AddUser(name, surname, mail, date, id);
        });
    }
}