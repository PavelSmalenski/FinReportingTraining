using System.ComponentModel.DataAnnotations;

namespace FinDatabase.Entities;

public class CompanyControl
{
    [Key]
    public int CompanyId { get; set; }

    public DateTime Lbd { get; set; }

    public DateTime Cbd { get; set; }

    public DateTime Nbd { get; set; }

    public int AccountId { get; set; }

    public int CtlCurrentAccountId { get; set; }

    public int CtlStaffAccountId { get; set; }

    public int CtlPlusplanAccountId { get; set; }

    public int CtlGendepAccount { get; set; }

    public byte CtlDayOfWeek { get; set; }

    public char RunIndex { get; set; }
}