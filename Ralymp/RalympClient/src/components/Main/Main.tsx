import React, {Component} from 'react';
import './main.scss';
import {Switch, Route} from 'react-router-dom'
import Rating from "../Rating/Rating";
import Home from "../Home/Home";
import Profile from "../Profile/Profile";

type Props = {activePage: string};
type State = {};
export default class Main extends Component<Props, State> {

    render() {
        const {activePage} = this.props;
        const ratingPage = ()=><Rating page={activePage}/>;
        return (
            <main className="Main">
                <Switch>
                    <Route exact path='/home' component={Home}/>
                    <Route exact path='/school' component={ratingPage}/>
                    <Route exact path='/teacher' component={ratingPage}/>
                    <Route exact path='/student' component={ratingPage}/>
                    <Route exact path='/subject' component={ratingPage}/>
                    <Route exact path='/profile' component={Profile}/>
                    <Route path="*" exact component={Home}/>
                </Switch>
            </main>
        );
    }
}

