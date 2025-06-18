namespace BankingSystem.API.DTOs.TransactionDTOs;

[XmlRoot("Operation")]
public class OperationDto
{

	public DateTime FileDate { get; set; }

	[XmlArray("Transactions")]
	[XmlArrayItem("Transaction")]
	public List<TransactionDto> Transactions { get; set; } = new();
}
