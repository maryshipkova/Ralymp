import React, {Component} from 'react'
import './header.scss';
import {Menu} from 'semantic-ui-react'
import {Link} from 'react-router-dom'

type Props = { activePage: string, onPageChanged: Function };
type State = {};
export default class Header extends Component<Props, State> {

    handleItemClick = (event: React.MouseEvent<HTMLElement>, {name}: any) => {
        this.props.onPageChanged(name);
    };


    render() {
        const {activePage} = this.props;
        const navItems = ['home', 'school', 'teacher', 'student', 'subject'];
        const navColor = 'violet';

        return (
            <header className='Header'>
                <Menu inverted>
                    {navItems.map(item => (
                        <Link to={`/${item}`} key={item}>
                            <Menu.Item
                                name={item}
                                active={activePage === item}
                                onClick={this.handleItemClick}
                                color={navColor}
                            />
                        </Link>
                    ))}

                </Menu>
            </header>
        )
    }
}
