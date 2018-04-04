namespace MenuStudent
{
    class Student
    {
        public Student(string rollNumber, string name, string phone, string email, int status)
        {
            this.SetRollNumber(rollNumber);
            this.SetName(name);
            this.SetPhone(phone);
            this.SetEmail(email);
            this.SetStatus(status);
        }
        public Student(int id, string rollNumber, string name, string phone, string email, int status)
        {
            this.SetId(id);
            this.SetRollNumber(rollNumber);
            this.SetName(name);
            this.SetPhone(phone);
            this.SetEmail(email);
            this.SetStatus(status);
        }

        public Student()
        {
        }

        private int id;

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        private string rollNumber;

        public string GetRollNumber()
        {
            return rollNumber;
        }

        public void SetRollNumber(string value)
        {
            rollNumber = value;
        }

        private string name;

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        private string phone;

        public string GetPhone()
        {
            return phone;
        }

        public void SetPhone(string value)
        {
            phone = value;
        }

        private string email;

        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string value)
        {
            email = value;
        }

        private int status;

        public int GetStatus()
        {
            return status;
        }

        public void SetStatus(int value)
        {
            status = value;
        }
    }
}
