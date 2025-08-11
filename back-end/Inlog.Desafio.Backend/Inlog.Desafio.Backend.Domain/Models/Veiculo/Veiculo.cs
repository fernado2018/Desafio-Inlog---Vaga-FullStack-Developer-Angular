
namespace Inlog.Desafio.Backend.Domain.Models.Veiculo{

   public class Veiculo
   {
       public long Id { get; set; }
       public string Chassi { get; set; }
       public TipoVeiculo TipoVeiculo { get; set; }
       public string Cor { get; set; }
       public string Placa{ get; set; }
       public string NumeroSerieRastreador{ get; set; }
       public Localizacao Localizacao { get; set; }
   
   }
}
