import React, {Component} from 'react';
import './App.scss';
import Header from "../Header/Header";
import Main from "../Main/Main";

type Props = {};
type State = { activePage: string };
export default class App extends Component<Props, State> {
    state = {activePage: 'home' };

    onNavItemChanged = (navItem:string) =>{this.setState({activePage : navItem})};
    render() {
        return (
            <div className="App">
                <Header activePage={this.state.activePage} onPageChanged={this.onNavItemChanged}/>
                <Main activePage={this.state.activePage}/>
            </div>
        );
    }
}

