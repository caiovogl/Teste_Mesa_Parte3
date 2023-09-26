using System;
using System.Reflection.Metadata.Ecma335;


public class Rendimento{

    public DateTime hoje = DateTime.Now;
    public DateTime calcDate = DateTime.Now;

    public double[] meses = {31,28,31,30,31,30,31,31,30,31,30,31};

    public Rendimento(){
        this.valor = 0;
        this.juros = 0;
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
    public double periodoAno
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

    private double altmes;
    public double periodoMes
    {
        get { return altmes + periodoAno * 12; }
        set { 
            if(altmes>=0){
                altmes = value; 
            }else{
                altmes = 0;
            }
        }
    }

    private double altdia;
    public double periodoDia
    {
        get { return altdia; }
        set { 
            if(altdia>=0){
                altdia = value; 
            }else{
                altdia = 0;
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

    public void exibeDados(){
        double valorInicial = this.valor;
        double rendTot = 0;
        double rendTotResgate = 0;
        double mesCalc = periodoMes;
        double diasCalc = periodoDia;
        bool diasNull = false;
        if(periodoDia==0){
            diasCalc++;
            diasNull = true;
        }
        double i = 0;
        while(diasCalc > 0){
            if(calcDate.Year%4==0 ){
                meses[1] = 29;
            }else{meses[1] = 28;}
            if(mesCalc>0){
                calcDate = calcDate.AddMonths(1);
                mesCalc--;
                i++;
            }else{
                double distFimMes = meses[calcDate.Month-1] - calcDate.Day;
                if(diasCalc>distFimMes){
                    i+=distFimMes/meses[calcDate.Month-1];
                    diasCalc-=distFimMes;
                    calcDate = calcDate.AddDays(distFimMes+1);
                    
                }else{
                    i+=diasCalc/meses[calcDate.Month-1];
                    calcDate = calcDate.AddDays(diasCalc);
                    diasCalc = 0;
                } 
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
            Console.WriteLine($"ano: {calcDate.Year} | mês: {calcDate.Month} | dia: {calcDate.Day} | rend.Total: {rendimento:C} | rend. líq.: {rendLiq:C} | resgate: {valorRes} | saldo: {saldo:C}");
            rendTot = rendimento;
            if(diasNull && mesCalc==0) diasCalc = 0;
        }
        if(!resgate){
            Console.WriteLine($"Com {valorInicial:C}, {this.juros:P} de juros em {periodoMes} meses e {periodoDia} dias, vai render {rendTot:C}.");
        }else{
            Console.WriteLine($"Com {valorInicial:C}, {this.juros:P} de juros em {periodoMes} meses e {periodoDia} dias, com saque no {valResgateMes}ºmês rendeu {rendTotResgate:C}");
        }
    }

}


