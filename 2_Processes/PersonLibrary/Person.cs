namespace PersonLibrary
{
    [Serializable]
    public class Person
    {
        string Name;
        string LastName;
        int Age;
        MaritalStatus MaritsalStatus;

    public Person(string Name, string Lastname, int Age)
        {
            this.Name = Name;
            this.LastName = Lastname;
            this.Age = Age;
            this.MaritsalStatus = MaritalStatus.Single;
        }

        public void Print()
        {
            Console.WriteLine("Person:\nName: " + Name + "\nLastname: " + LastName + "\nAge: " + Age + "\nMarital Status:" + MaritsalStatus.ToString());
        }
    }

    public enum MaritalStatus
    {
        Merried,
        Single
    }
}
