using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AFORO255.MS.TEST.Transaction.Models;

public class TransactionModel
{
    [BsonId]
    public ObjectId Id { get; set; }        
    [BsonElement("id_transaction")]    
    public int? IdTransaction { get; set; }    
    [BsonElement("id_invoice")]
    public int? InvoiceId { get; set; }    
    [BsonElement("amount")]
    public decimal? Amount { get; set; }    
    [BsonElement("date")]
    public string? CreationDate { get; set; }    
}
