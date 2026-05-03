using System;

namespace DO
{
    public record Customer(int Id, string Name, string? Address, string Phone)
    {
       
        public Customer() : this(0,"", null, "") 
        {

        }
        public override string ToString() =>
            $"Customer ID: {Id},\n Name: {Name},\n Address: {Address},\n Phone: {Phone}";
    }
}

