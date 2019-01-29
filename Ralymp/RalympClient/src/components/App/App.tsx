import React, {Component} from 'react';
import './App.scss';
import Header from "../Header/Header";
import Main from "../Main/Main";

type Props = {};
type State = { activeNavItem: string };
export default class App extends Component<Props, State> {
    state = {activeNavItem: 'home' };

    onNavItemChanged = (navItem:string) =>{this.setState({activeNavItem : navItem})};
    render() {
        return (
            <div className="App">
                <Header activeItem={this.state.activeNavItem} onNavItemChanged={this.onNavItemChanged}/>
                <Main activeItem={this.state.activeNavItem}/>
            </div>
        );
    }
}

