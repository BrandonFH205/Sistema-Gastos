using System;

namespace proyectog.Models
{
public class Ingreso
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty; // Inicializa con un valor predeterminado
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
}
}