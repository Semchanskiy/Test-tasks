using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SearchHub : MonoBehaviour
{
    [SerializeField] private PostProcess _postProcess;
    [SerializeField] private Material[] _items;
    private bool _isSearching = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnOffSearchMode()
    {
        if (_isSearching)
        {
            _postProcess.enabled = false;
            DisableOutlineItem();
        }
        else
        {
            _postProcess.enabled = true;
            EnableOutlineItem();
        }
        _isSearching = !_isSearching;
    }

    private void DisableOutlineItem()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i].SetFloat("_OutlineWidth", 0);
        }
    }

    private void EnableOutlineItem()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            _items[i].SetFloat("_OutlineWidth", 0.03f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
