using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyBillingDashboard.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public int? InsuranceID { get; set; }
        public int? SecondaryInsuranceID { get; set; }

        [ForeignKey("InsuranceID")]
        public InsuranceProvider PrimaryInsurance { get; set; }

        [ForeignKey("SecondaryInsuranceID")]
        public InsuranceProvider SecondaryInsurance { get; set; }
    }

    public class Bill
    {
        [Key]
        public int BillID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }

        [Required]
        public DateTime ServiceDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }
    }

    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int BillID { get; set; }

        [ForeignKey("BillID")]
        public Bill Bill { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentType { get; set; } // e.g., Cash, Credit, Check, Insurance-Direct
    }

    public class InsuranceProvider
    {
        [Key]
        public int InsuranceID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProviderName { get; set; }

        [Required]
        [MaxLength(100)]
        public string PolicyNumber { get; set; }

        [MaxLength(100)]
        public string SecondaryPolicyNumber { get; set; }
    }

    public class Prescription
    {
        [Key]
        public int PrescriptionID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }

        [Required]
        public int DrugID { get; set; }

        [ForeignKey("DrugID")]
        public Drug Drug { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateIssued { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal InsuranceCoverageAmount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal CopayAmount { get; set; }
    }

    public class Drug
    {
        [Key]
        public int DrugID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DrugName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Dose { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitCost { get; set; }
    }
}
