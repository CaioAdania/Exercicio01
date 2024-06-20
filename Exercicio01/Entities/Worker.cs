using Exercicio01.Entities.Enums;

namespace Exercicio01.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }// associação
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); //* significa vários o que indica uma lista, esta parte é uma associação

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department) //via de regra, quando tiver uma associação "para muitos", não pode incluir no construtor.
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract) //muito utilizado em associação de objetos
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract) //muito utilizado em associação de objetos
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}
