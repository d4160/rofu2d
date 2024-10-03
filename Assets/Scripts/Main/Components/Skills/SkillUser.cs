using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que representa a un usuario de habilidades.
/// </summary>
public class SkillUser : ComponentBase
{
    protected List<ISkill> _skills = new();

    /// <summary>
    /// Agrega una nueva habilidad al usuario.
    /// </summary>
    /// <param name="skill">La habilidad a agregar.</param>
    public void AddSkill(ISkill skill)
    {
        if (!_skills.Contains(skill))
        {
            skill.SkillUser = this;
            _skills.Add(skill);

            if (skill.Enabled)
            {
                skill.Start();
            }
        }
    }

    /// <summary>
    /// Remueve una habilidad del usuario.
    /// </summary>
    /// <param name="skill">La habilidad a remover.</param>
    public void RemoveSkill(ISkill skill)
    {
        skill.SkillUser = null;
        _skills.Remove(skill);
    }

    /// <summary>
    /// Habilita una habilidad específica.
    /// </summary>
    /// <param name="skillType">El tipo de habilidad a habilitar.</param>
    public void EnableSkill<T>() where T : ISkill
    {
        var skill = _skills.Find(s => s is T);
        if (skill != null)
        {
            skill.Enabled = true;
        }
    }

    /// <summary>
    /// Deshabilita una habilidad específica.
    /// </summary>
    /// <param name="skillType">El tipo de habilidad a deshabilitar.</param>
    public void DisableSkill<T>() where T : ISkill
    {
        var skill = _skills.Find(s => s is T);
        if (skill != null)
        {
            skill.Enabled = false;
        }
    }

    /// <summary>
    /// Usa una habilidad específica.
    /// </summary>
    /// <param name="skillType">El tipo de habilidad a usar.</param>
    public void UseSkill<T>() where T : ISkill
    {
        var skill = _skills.Find(s => s is T);
        if (skill != null && skill.Enabled)
        {
            skill.Execute();
        }
    }

    /// <summary>
    /// Actualiza todas las habilidades habilitadas.
    /// </summary>
    private void Update()
    {
        foreach (var skill in _skills)
        {
            if (skill.Enabled)
            {
                skill.Update();
            }
        }
    }

    /// <summary>
    /// Actualiza todas las habilidades habilitadas.
    /// </summary>
    private void FixedUpdate()
    {
        foreach (var skill in _skills)
        {
            if (skill.Enabled)
            {
                skill.FixedUpdate();
            }
        }
    }
}
