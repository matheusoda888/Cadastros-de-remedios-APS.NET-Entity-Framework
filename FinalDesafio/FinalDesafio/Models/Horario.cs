using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalDesafio.Models;

public partial class Horario
{
    public int Id { get; set; }

    public string NomeRemedio { get; set; } = null!;

    public string NomePaciente { get; set; } = null!;
    [Display(Name = "Tempo")]
    public int Tempo { get; set; }
    [Display(Name = "Horário")]
    public TimeSpan Horario1 { get; set; }
    [Display(Name = "Nome do paciente")]
    public virtual Paciente NomePacienteNavigation { get; set; } = null!;
    [Display(Name = "Nome do remédio")]
    public virtual Remedio NomeRemedioNavigation { get; set; } = null!;
}
