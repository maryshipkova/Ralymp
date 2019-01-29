import React, {Component} from 'react';
import './rating.scss';

type Props = {page:string};
type State = { };
export default class Rating extends Component<Props, State> {
    render() {
        return (
            <section className="Rating">
                <h2 >{this.props.page}</h2>
            </section>
        );
    }
}

