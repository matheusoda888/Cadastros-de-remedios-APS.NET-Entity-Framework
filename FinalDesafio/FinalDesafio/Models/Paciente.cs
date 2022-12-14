using System;
using System.Collections.Generic;

namespace FinalDesafio.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Horario> Horarios { get; } = new List<Horario>();
}
