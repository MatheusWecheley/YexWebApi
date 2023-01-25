using System;

namespace YexWebApi.Models.Barber
{
    public class Barber
    {
        public int Id { get; set; }
        public string NameUsual { get; set; }
        public string Owner { get; set; }
        public string email { get; set; }
        public string CnpjCpf { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public int BarberNum { get; set; }
        public int Cep { get; set; }
        public string City { get; set; }
        public string Cellphone { get; set; }
        public string Tellphone { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

            
    }
}
