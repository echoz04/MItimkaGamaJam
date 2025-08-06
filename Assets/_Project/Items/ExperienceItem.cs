using UnityEngine;
using System.Collections.Generic;

public class ExperienceItem : Item
{
    public enum ExperienceTier
    {
        COMMON,
        RARE,
        EPIC,
        LEGENDARY,
    };

    private Dictionary<ExperienceTier, float> experienceCount = new Dictionary<ExperienceTier, float>(){
        {ExperienceTier.COMMON, 1},
        {ExperienceTier.RARE, 8},
        {ExperienceTier.EPIC, 16},
        {ExperienceTier.LEGENDARY, 50},
    };

    private Dictionary<ExperienceTier, Color> experienceColor = new Dictionary<ExperienceTier, Color>(){
        {ExperienceTier.COMMON, Color.blue},
        {ExperienceTier.RARE, Color.green},
        {ExperienceTier.EPIC, Color.magenta},
        {ExperienceTier.LEGENDARY, Color.yellow},
    };

    public ExperienceTier Tier = ExperienceTier.COMMON;

    public override void Start()
    {
        base.Start();
        SpriteColorComponent spriteColor = GetComponent<SpriteColorComponent>();
        spriteColor.BaseColor = experienceColor[Tier];
    }


    public override void Apply()
    {
        ExperienceController.Insntance.GiveExperience((int)experienceCount[Tier]);
        base.Apply();
    }
};
