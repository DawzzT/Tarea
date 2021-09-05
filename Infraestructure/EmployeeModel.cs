using Domain;
using System;

namespace Infraestructure
{
    public class EmployeeModel
	{ 


        public EmployeeModel() { }

		public Employee[] empleados;
		public void add(Employee e)
		{

			if (e == null)
			{

				throw new ArgumentNullException("Error, no puede ser null");
			}
			else if (empleados == null)
			{
				empleados = new Employee[1];
				empleados[0] = e;

			}
			else
			{


				Employee[] tmp = new Employee[empleados.Length + 1];
				Array.Copy(empleados, tmp, empleados.Length);
				empleados = new Employee[tmp.Length];
				Array.Copy(tmp, empleados, tmp.Length - 1);
				empleados[tmp.Length - 1] = e;
			}
		}
		
		public decimal SueldoMaximo()
        {
            
            
            Array.Sort(empleados, new Employee.EmployeeWageComparer());
            return empleados[empleados.Length -1].Wage;
        }

        public decimal GetSalarioMinimo()
        {
            if(empleados == null)
            {
                return 0;
            }
            Array.Sort(empleados, new Employee.EmployeeWageComparer());
            return empleados[0].Wage;
        }

        public decimal GetSalarioPromedio()
        {
            if (empleados == null)
            {
                return 0;
            }
            decimal suma = 0M;
            foreach (Employee e in empleados)
            {
                suma += e.Wage;
            }

            return (suma / empleados.Length);
        }

        public decimal GetMayorPromedio()
        {
            decimal[] salarioM = new decimal[10];
            int i = 0;
            foreach (Employee e in empleados)
            {
                while (i < empleados.Length)
                {
                    if (e.Wage > GetSalarioPromedio())
                    {
                        salarioM[i] = e.Wage;
                    }
                    i++;
                }

            }
            return salarioM[empleados.Length - 1];
        }
        public decimal GetSalarioMenorPromedio()
        {
            decimal[] salarioMen = new decimal[10];
            int i = 0;
            foreach (Employee e in empleados)
            {
                while (i < empleados.Length)
                {
                    if (e.Wage < GetSalarioPromedio())
                    {
                        salarioMen[i] = e.Wage;
                    }
                    i++;
                }

            }
            return salarioMen[empleados.Length - 1];
        }

    }
}
