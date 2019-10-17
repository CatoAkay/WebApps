namespace Model
{
	public class Billett
	{
		public int ID { get; set; }
	    public virtual Reise Reise { get; set; }
        public virtual Kunde Kunde { get; set; }
	}
}