using System;
using System.Reflection.Metadata.Ecma335;


public class Rendimento{
    public Rendimento(){
        this.valor = 0;
        this.juros = 0;
        this.periodo = 0;
        this.decisao = "N";
    }

    private double val;
    public double valor
    {
        get { return val; }
        set { 
            if(val>=0){
                val = value; 
            }else{
                val = 0;
            }
        }
    }

    private double jur;
    public double juros
    {
        get { return jur/100; }
        set { 
            if(jur>=0){
                jur = value; 
            }else{
                jur = 0;
            }
        }
    }
    
    private double tempo;
    public double periodo
    {
        get { return tempo; }
        set { 
            if(tempo>=0){
                tempo = value; 
            }else{
                tempo = 0;
            }
        }
    }

    private string altdec;
    public string decisao
    {
        get { return altdec.ToUpper().Substring(0,1); }
        set { 
            if(altdec!=""){
                altdec = value;
            }else{
                altdec = "N";
            }
        }
    }

    
    private bool altres;
    public bool resgate{
        get{
            if(decisao=="S"){
                altres = true;
            }else{
                altres = false;
            }
            return altres;
        }
    }

    private double altvalres;
    public double valResgate
    {
        get { return altvalres; }
        set { 
            if(altvalres>=0){
                altvalres = value; 
            }else{
                altvalres = 0;
            }
        }
    }

    private double altvalmes;
    public double valResgateMes
    {
        get { return altvalmes; }
        set { 
            if(altvalmes>=0){
                altvalmes = value; 
            }else{
                altvalmes = 0;
            }
        }
    }

    public static double jurComp(double valor, double juros, double tempo){
        double rend = valor*Math.Pow(1+juros,tempo);
        return rend;
    }

    public double rendaTotal{
        get{ return jurComp(valor,juros,periodo);}
    }

    public void exibeDados(){
        double rendTot = rendaTotal;
        double rendTotResgate = 0;
        for(double i = 1; i < periodo+1; i++){
            if(i>periodo){
                i = periodo;
            }
            double rendimento = jurComp(valor,juros,i);
            double valorRes = 0;
            if(i>valResgateMes && resgate){
                rendimento = jurComp(valor,juros,i-valResgateMes);
                rendTotResgate = rendimento;
            }
            double saldo = rendimento;
            double rendLiq = rendimento-valor;
            if(resgate && i==valResgateMes){
                valor = rendimento - valResgate;
                valorRes = valResgate;
                saldo = valor;
            }
            Console.WriteLine($"mês {i} | rend.Total: {rendimento:C} | rend. líq.: {rendLiq:C} | resgate: {valorRes} | saldo: {saldo:C}");
        }
        if(!resgate){
            Console.WriteLine($"Com {this.valor:C}, {this.juros:P} de juros em {periodo} meses, vai render {rendTot:C}.");
        }else{
            Console.WriteLine($"Com {this.valor:C}, {this.juros:P} de juros em {periodo} meses, iria render {rendTot:C} sem saque no {valResgateMes}ºmês.");
            Console.WriteLine($"Mas rendeu {rendTotResgate:C}");
        }
    }

}


