using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Nivel;
    public int Fuerza, Destreza, Constitucion, Inteligencia, Sabiduria, Carisma;
    public int ArmorClass, HitPoints, BonoCompetencia;
    public bool SalvacionFuerza, SalvacionDestreza, SalvacionConstitucion, SalvacionInteligencia, SalvacionSabiduria, SalvacionCarisma;
    public bool AcrobaticsDex, AnimalHandlingWis, ArcanaInt, AthleticsStr, DeceptionCha, HistoryInt, InsightWis;
    public bool IntimidationCha, InvestigationInt, MedicineWis, NatureInt, PerceptionWis, PerformanceCha;
    public bool PersuasionCha, ReligionInt, SleightOfHandDex, StealthDex, SurvivalWis;


    // Modificadores: (Stat-10)/2

    // Start is called before the first frame update
    void Start()
    {
        Nivel= 1;
        Fuerza= 8;
        Destreza= 8;
        Constitucion= 8;
        Inteligencia= 8;
        Sabiduria= 8;
        Carisma= 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (Nivel <= 4) { BonoCompetencia = 2; }
        else if (Nivel <= 8 && Nivel >= 5) { BonoCompetencia = 3;}
        else if (Nivel >= 9 && Nivel <= 12) { BonoCompetencia = 4; }
        else if (Nivel >= 13 && Nivel <= 16) { BonoCompetencia = 5; }
        else if (Nivel >= 17 && Nivel <= 20) { BonoCompetencia = 6; }
        if (Nivel < 1) { Nivel = 1; }
        if (Nivel > 20) { Nivel = 20; }

        if (Fuerza < 8) { Fuerza = 8; }
        if (Destreza < 8) { Destreza = 8; }
        if (Constitucion < 8) { Constitucion = 8; }
        if (Inteligencia < 8) { Inteligencia = 8; }
        if (Sabiduria < 8) { Sabiduria = 8; }
        if (Carisma < 8) { Carisma = 8; }

        if (Fuerza > 20) { Fuerza = 20; }
        if (Destreza > 20) { Destreza = 20; }
        if (Constitucion > 20) { Constitucion = 20; }
        if (Inteligencia > 20) { Sabiduria = 20; }
        if (Sabiduria > 20) { Sabiduria = 20; }
        if (Carisma > 20) { Carisma = 20; }

        ArmorClass = 10 + ((Destreza - 10) / 2);

        HitPoints = 10 + ((Constitucion - 10) / 2);

        
    }



}
