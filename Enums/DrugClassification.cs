namespace MedicationManager.Enums;

public enum DrugClassification
{
    OverTheCounter,     // Sem tarja / Venda livre (Maps to 0)
    Prescription,       // Tarja Vermelha / Sob prescrição médica (Maps to 1)
    Controlled          // Tarja Preta / Medicamento controlado (Maps to 2)
}