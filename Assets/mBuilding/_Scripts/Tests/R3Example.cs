using R3;
using ObservableCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class R3Example : MonoBehaviour
{
/*    void Start()
    {
        var subject = new Subject<Unit>();

        // Use Select to map Unit to a message string
        var observable = subject.Select(_ => "Event Triggered!");

        // Subscribe to the observable
        observable.Subscribe(message => Debug.Log(message));

        // Emit Unit.Default to trigger the event
        subject.OnNext(Unit.Default);
        subject.OnNext(Unit.Default);
    }*/
    //reactive property
    private void Ex1()
    {
        ReactiveProperty<int> _health; 
        _health = new ReactiveProperty<int>(100);
        _health.Subscribe(newHealth => { Debug.Log($"{_health}"); });

        for (int i = 0; i < 10; i++)
        {
            _health.Value -= 2;
        }
    }
    // ReadOnly reactive property
    private ReactiveProperty<int> _health2;
    public ReadOnlyReactiveProperty<int> Health2 => _health2 = new ReactiveProperty<int>(100);
    private void Ex2()
    {
        Health2.Subscribe(newHealth => { Debug.Log($"{newHealth}"); });
       // Health2.CurrentValue

        for (int i = 0; i < 10; i++)
        {
            _health2.Value -= 2;
        }
    }
    

    //Observable
    private ReactiveProperty<int> _health3 = new ReactiveProperty<int>();
    public Observable<int> Health3 => _health3;
    private void Ex3()
    {
        //Можно только подписаться
        Health3.Subscribe(newHealth => { Debug.Log($"{newHealth}"); });

        for (int i = 0; i < 10; i++)
        {
            _health3.Value += 2;
        }
    }

    //Subject
    private readonly Subject<int> _healthChanged = new Subject<int>();
    public Observable<int> HealthChanged => _healthChanged;
    //public ReadOnlyReactiveProperty<int> Health3;
    private void Ex4()
    {
        _healthChanged.OnNext(100); //will not happen
        HealthChanged.Subscribe(newHealth => { Debug.Log($"{newHealth}"); });

        for (int i = 0; i < 10; i++)
        {
            _healthChanged.OnNext(10);
        }
    }

    //Oтписка
    private readonly ReactiveProperty<int> _health5 = new ReactiveProperty<int>();
    private IDisposable _disposable5;
    public Observable<int> Health5 => _health5;
    private void Ex5()
    {

        _disposable5 = Health5.Subscribe(newHealth => { Debug.Log($"{newHealth}"); });

        for (int i = 0; i < 10; i++)
        {
            _health5.Value += 1;
        }
        _disposable5.Dispose();

        //not happen
        _health5.OnNext(9999);
    }

    private readonly ReactiveProperty<int> _health6 = new ReactiveProperty<int>();
    private readonly ReactiveProperty<int> _armor6 = new ReactiveProperty<int>();
    public Observable<int> Health6 => _health6;
    public Observable<int> Armor6 => _armor6;
    
    private readonly CompositeDisposable _compositeDisposable6 = new CompositeDisposable();
    private void Ex6()
    {
        _health6.Value += 1;
        _armor6.Value += 1;
        {
            var subscriptionHealth = Health6.Subscribe(newHealth => { Debug.Log($"new Heal {newHealth}"); });
            var subscriptionArmor = Armor6.Subscribe(newArmor => { Debug.Log($"new Armor {newArmor}"); });

            _compositeDisposable6.Add( subscriptionHealth );
            _compositeDisposable6.Add( subscriptionArmor );
        }

        _armor6.Value += 1;

        for (int i = 0; i < 10; i++)
        {
            _health6.Value += 1;
        }
        _armor6.Value += 1;
        _compositeDisposable6.Dispose();

        //not happen
        _health6.OnNext(9999);
    }

    //merge 
    private readonly ReactiveProperty<int> _health7 = new ReactiveProperty<int>();
    private readonly ReactiveProperty<int> _armor7 = new ReactiveProperty<int>();
    public Observable<int> Health7 => _health7; 
    public Observable<int> Armor7 => _armor7; 

    private void Ex7()
    {
        Health7.Merge(Armor7).Subscribe(newValue =>
        {
            Debug.Log($"Event H {_health7}, A {_armor7}");
        });
        _armor7.Value += 1;

        for (int i = 0; i < 10; i++)
        {
            _health7.Value += 1;
        }
        _armor7.Value += 1;

        _health7.OnNext(9999);
    }

    //filtration
    private readonly ReactiveProperty<int> _health8 = new ReactiveProperty<int>();
    //private readonly ReactiveProperty<int> _armor8 = new ReactiveProperty<int>();
    public Observable<int> Health8 => _health8;
    //public Observable<int> Armor8 => _armor8;

    private void Ex8()
    {
        Health8.Where(newValue => newValue < 5).Subscribe(newValue =>
        {
            Debug.Log($"Event H {_health8}");
        });

        for (int i = 0; i < 10; i++)
        {
            _health8.Value += 1;
        }

        _health8.OnNext(9999);
    }


    private readonly ReactiveProperty<int> _health9;
    public Observable<int> Health9 => _health9;
    private void Ex9()
    {
        var texts = new List<string>();
        for (int i = 0;i < 10; i++)
        {
            texts.Add($"Step {i}");
        }
        var defferedPrints = texts.Select((text, index) => Observable.Defer(() => Print9(text)));
        var queuedPrints = Observable.Concat(defferedPrints);
        var lastPrint = queuedPrints.TakeLast(1);
        lastPrint.Subscribe(newValue =>
        {
            Debug.Log("All elements is over");
        });                                         

    }
    private Observable<Unit> Print9(string text)
    {
        Debug.Log(text);
        return Observable.Timer(TimeSpan.FromSeconds(1), UnityTimeProvider.UpdateIgnoreTimeScale);
    }




    private event Action<int> ValueChanged10;
    private void Ex10()
    {
        Observable.FromEvent<int>(a => ValueChanged10 += a, a => ValueChanged10 -= a)
            .Subscribe(newValue =>
            {
                Debug.Log($"{newValue}");
            });
        ValueChanged10?.Invoke(100);
        ValueChanged10?.Invoke(100);
    }

    //
    private readonly ObservableList<string> _observableCollection11  = new ObservableList<string>();
    public IObservableCollection<string> ObservableCollection11 => _observableCollection11;

    public void Ex11()
    {
        _observableCollection11.Add("a");
        _observableCollection11.Add("b");

        ObservableCollection11.ObserveAdd().Subscribe(e =>
        {
            string all = "Element Added ";
            foreach(string s in _observableCollection11)
            {
                all += s;
                all += ' ';
            }
            Debug.Log($"Elements {all}");
        });
        ObservableCollection11.ObserveRemove().Subscribe(e =>
        {
            string all = "Element Removed ";
            foreach (string s in _observableCollection11)
            {
                all += s;
                all += ' ';
            }
            Debug.Log($"Elements {all}");
        });

        _observableCollection11.Add("c");
        _observableCollection11.Remove("a");
        _observableCollection11.Add("a");
        _observableCollection11.Add("ZZ");

    }



}
