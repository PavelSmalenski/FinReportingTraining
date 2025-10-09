using System.ComponentModel.DataAnnotations;

namespace FinDatabase.Entities;

public class CenterControl
{
    [Key]
    public int CenterId { get; set; }

    [MaxLength(30)]
    public string CenterName { get; set; } = null!;

    public byte BankCode { get; set; }

    public byte Zone { get; set; }

    public byte Region { get; set; }

    public int ReportCenterId { get; set; }

    public int ClusCentAdmIbtCenterId { get; set; }

    public int RegnCentAdmIbtCenterId { get; set; }

    [MaxLength(25)]
    public string Type { get; set; } = null!;

    public byte Suite { get; set; }

    public int CsvIbtCenterId { get; set; }

    public char PrintStatus { get; set; }

    [MaxLength(3)]
    public string Country { get; set; } = null!;

    public int CompanyId { get; set; }

    public char TestIndex { get; set; }

    [MaxLength(4)]
    public string Stat { get; set; } = null!;

    [MaxLength(4)]
    public string InstutN { get; set; } = null!;

    [MaxLength(2)]
    public string InternalBank { get; set; } = null!;
}