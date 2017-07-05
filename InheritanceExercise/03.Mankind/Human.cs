using System;
using System.Text;

namespace _03.Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value[0].ToString().ToUpper() != value[0].ToString())
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.firstName)}");
                }

                if (value.Length < 4)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: {nameof(this.firstName)}");
                }

                this.firstName = value;
            }
        }

        public virtual string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value[0].ToString().ToUpper() != value[0].ToString())
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {nameof(this.lastName)}");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException($"Expected length at least 3 symbols! Argument: {nameof(this.lastName)}");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}")
                .AppendLine($"Last Name: {this.LastName}");

            return sb.ToString();
        }
    }
}
