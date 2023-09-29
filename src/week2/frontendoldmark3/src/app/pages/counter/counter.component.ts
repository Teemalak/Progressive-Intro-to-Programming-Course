import { Component, signal } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Store } from "@ngrx/store";
import { counterFeature } from "./state";
import { CounterEvents } from "./state/counter.actions";
import { PrefsComponent } from "./components/prefs/prefs.component";

@Component({
  selector: "app-counter",
  standalone: true,
  template: `
    <div>
      <button (click)="decrement()" class="btn btn-circle btn-sm">-</button>
      <span>{{ current() }}</span>
      <button (click)="increment()" class="btn btn-circle btn-sm">+</button>
    </div>
    <div>
      <button
        (click)="reset()"
        [disabled]="resetDisabled()"
        class="btn btn-sm btn-accent"
      >
        Reset
      </button>
    </div>
    <div>
      <app-prefs />
    </div>
  `,
  styles: [],
  imports: [CommonModule, PrefsComponent],
})
export class CounterComponent {
  current = this.store.selectSignal(counterFeature.selectCurrent); // we have private local state. The current value can only be seen and used here. OOP 101.
  resetDisabled = this.store.selectSignal(
    counterFeature.selectResetShouldBeDisabled,
  );
  constructor(private readonly store: Store) {
    store.dispatch(CounterEvents.counterEntered());
  }
  increment() {
    this.store.dispatch(CounterEvents.incrementClicked());
    //this.current.set(this.current() + 1);
  }

  decrement() {
    this.store.dispatch(CounterEvents.decrementClicked());
    //this.current.set(this.current() - 1);
  }

  reset() {
    this.store.dispatch(CounterEvents.resetClicked());
  }
}
