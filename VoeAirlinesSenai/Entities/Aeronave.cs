
//NameSpace é um conjunto de classe
//NameSpace é uma divisão Lógica.
namespace VoeAirlinesSenai.Entities;
//Classe é um conjunto de Objetos
// Objeto é uma instacia de uma classe
public class Aeronave
{
    public Aeronave(string fabricante, int modelo, int codigo)
    {
        Fabricante = fabricante;
        Modelo = modelo;
        Codigo = codigo;
    }

    //propriedades Automáticas
    //características do Objeto
    //Automático - porquer gera o GET SET
    //métodos SET - atribui (insert)
    //métodos GET - recupera (retorna)
    //POCO - é uma classe, que não depende de nenhuma classe base específica da estrutura.
    // É como qualquer outra classe normal .NET. Devido a isso, eles são chamados de Objetos CLR Simples. 
    //Essas entidades POCO (também conhecidas como objetos ignorantes de persistência) /////FOCO É O OBJETO /////

    public int Id { get; set; }
    public string Fabricante { get; set; }
    public int Modelo { get; set; }
    public int Codigo { get; set; }
    public ICollection<Manutencao> Manutencoes { get; set; } = null!;
    public ICollection<Voo> Voos { get; set; } = null!;

    //Lista de Navegação são as ICollection !
}

