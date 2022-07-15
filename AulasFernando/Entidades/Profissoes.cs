namespace AulasFernando.Entidades
{
    public class Profissoes
    {
        public int ID { get; set; }
        public string Area { get; set; }
        public string Profissao { get; set; }
        public int FormacaoID { get; set; } //Vai receber a chave estrângeira da outra classe de entidade
        public Formacao Formacao { get; set; } //Vai receber todos os dados da chave estrângeira  
    }
}
