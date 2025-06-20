namespace BankingSystem.Application.DTOs.TransactionDTOs;

[XmlRoot("Operation")]
public class OperationDto
{

	public DateTime FileDate { get; set; }

	[XmlArray("Transactions")]
	[XmlArrayItem("Transaction")]
	public List<TransactionExportDto> Transactions { get; set; } = new();
}
