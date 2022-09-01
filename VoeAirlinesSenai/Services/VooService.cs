using System.Text;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModels;

namespace VoeAirlinesSenai.Services;
public class VooService
{
    private readonly VoeAirlinesContext _context;
    private readonly IConverter _converter;

    public VooService(VoeAirlinesContext context, IConverter converter)
    {
        _context = context;
        _converter = converter;
    }
    //Adicionar Voo
    public DetalhesVooViewModel AdicionarVoo(AdicionarVooViewModel dados)
    {
        var voo = new Voo(dados.Origem, dados.Destino, dados.DataHoraPartida, dados.DataHoraChegada, dados.AeronaveId, dados.PilotoId);
        _context.Add(voo);
        _context.SaveChanges();
        return new DetalhesVooViewModel
        (
            voo.Id,
            voo.Origem,
            voo.Destino,
            voo.DataHoraPartida,
            voo.DataHoraChegada,
            voo.AeronaveId,
            voo.PilotoId
        );
    }
    // Listar Todos voo
    public IEnumerable<ListarVooViewModel> ListarVoos()
    {
        return _context.Voos.Select(v => new ListarVooViewModel(v.Id, v.Origem, v.Destino, v.DataHoraPartida, v.DataHoraChegada));
    }
    //Listar Voo Pelo Id
    public DetalhesVooViewModel? ListarVooPeloId(int id)
    {
        var voo = _context.Voos.Find(id);
        if (voo != null)
        {
            return new DetalhesVooViewModel
            (
                voo.Id,
                voo.Origem,
                voo.Destino,
                voo.DataHoraPartida,
                voo.DataHoraChegada,
                voo.AeronaveId,
                voo.PilotoId
            );
        }
        return null;
    }
    //Atualizar Voo
    public DetalhesVooViewModel? AtualizarVoo(AtualizarVooViewModel dados)
    {
        var voo = _context.Voos.Find(dados.Id);
        if (voo != null)
        {
            voo.Origem = dados.Origem;
            voo.Destino = dados.Destino;
            voo.DataHoraPartida = dados.DataHoraPartida;
            voo.DataHoraChegada = dados.DataHoraChegada;
            voo.AeronaveId = dados.AeronaveId;
            voo.PilotoId = dados.PilotoId;
            _context.Update(voo);
            _context.SaveChanges();
        }
        return null;
    }
    //Deletar Voo
    public void ExcluirVoo(int id)
    {
        var voo = _context.Voos.Find(id);
        if (voo != null)
        {
            _context.Remove(voo);
            _context.SaveChanges();
        }
    }
    //Converte HTML PARA PDF .GERAR FICHAR EM PDF 
  public byte[]? GerarFichaDoVoo(int id)
    {
        var voo = _context.Voos.Include(v => v.Aeronave)
                               .Include(v => v.Piloto)
                               .Include(v => v.Cancelamento)
                               .FirstOrDefault(v => v.Id == id);

        if (voo != null)
        {
            var builder = new StringBuilder();

            builder.Append($"<h1 style='text-align: center'>Ficha do Voo { voo.Id.ToString().PadLeft(10, '0') }</h1>")
                   .Append($"<hr>")
                   .Append($"<p><b>ORIGEM:</b> { voo.Origem} (saída em { voo.DataHoraPartida:dd/MM/yyyy} às { voo.DataHoraPartida:hh:mm})</p>")
                   .Append($"<p><b>DESTINO:</b> { voo.Destino} (chegada em { voo.DataHoraChegada:dd/MM/yyyy} às { voo.DataHoraChegada:hh:mm})</p>")
                   .Append($"<hr>")
                   .Append($"<p><b>AERONAVE:</b> { voo.Aeronave!.Codigo } ({ voo.Aeronave.Fabricante } { voo.Aeronave.Modelo })</p>")
                   .Append($"<hr>")
                   .Append($"<p><b>PILOTO:</b> { voo.Piloto!.Nome } ({ voo.Piloto.Matricula})</p>")
                   .Append($"<hr>");
            if (voo.Cancelamento != null)
            {
                builder.Append($"<p style='color: red'><b>VOO CANCELADO:</b> { voo.Cancelamento.Motivo }</p>");
            }

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = builder.ToString(),
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _converter.Convert(doc);
        }

        return null;
    }
}