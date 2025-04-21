using System;
using System.Collections.Generic;

namespace WIF.Core.Models;

public partial class BBWalletImport
{
    public long Id { get; set; }

    public Guid? Uid { get; set; }

    public Guid? UserUid { get; set; }

    public string? Account { get; set; }

    public string? Category { get; set; }

    public string? Currency { get; set; }

    public double? Amount { get; set; }

    public double? RefCurrencyAmount { get; set; }

    public string? Type { get; set; }

    public string? PaymentType { get; set; }

    public string? PaymentTypeLocal { get; set; }

    public string? Note { get; set; }

    public DateTime? Date { get; set; }

    public float? GpsLatitude { get; set; }

    public float? GpsLongitude { get; set; }

    public float? GpsAccuracyInMeters { get; set; }

    public float? WarrantyInMonth { get; set; }

    public bool? Transfer { get; set; }

    public string? Payee { get; set; }

    public string? Labels { get; set; }

    public long? EnvelopeId { get; set; }

    public bool? CustomCategory { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? CreatedByUserUid { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public Guid? UpdatedByUserUid { get; set; }
}
