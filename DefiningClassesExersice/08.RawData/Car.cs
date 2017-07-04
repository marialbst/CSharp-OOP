using System;
using System.Collections.Generic;

namespace _08.RawData
{
    public class Car
    {
        private string model;
        private Cargo cargo;
        private Engine engine;
        private List<Tyre> tyres;

        public Car(string model, Cargo cargo, Engine engine, List<Tyre> tyres)
        {
            this.model = model;
            this.cargo = cargo;
            this.engine = engine;
            this.tyres = tyres;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public List<Tyre> Tyres
        {
            get { return this.tyres; }
            set
            {
                if (value.Count != 4)
                {
                    throw new Exception("Tyres must be exactly 4!");
                }

                this.tyres = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Model}";
        }
    }
}
