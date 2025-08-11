
namespace Inlog.Desafio.Backend.Domain.Models.Veiculo
{
    public class Localizacao
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long IdVeiculo { get; set; }
        public Veiculo Veiculo { get; set; }
        
    }
}