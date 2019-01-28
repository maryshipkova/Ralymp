import React, {Component} from 'react';
import './App.scss';
import Header from "../Header/Header";
import Main from "../Main/Main";

export default class App extends Component {
    render() {
        return (
            <div className="App">
                <Header/>
                <Main/>
            </div>
        );
    }
}

