using Domain;
using System;
using System.Collections.Generic;
using System.Text;

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

        public decimal GetSalarioMenorPromedio()
        {
            decimal x = 0;
            for (int i = 0; i < empleados.Length; i++)
            {
                if (empleados[i].Wage > GetSalarioPromedio())
                {

                }
         
            }
            return x;
        }

    }
}
