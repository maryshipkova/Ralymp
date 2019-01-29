import React, {Component} from 'react'
import './header.scss';
import {Menu} from 'semantic-ui-react'
import {Link} from 'react-router-dom'

type Props = { activeItem: string, onNavItemChanged: Function };
type State = {};
export default class Header extends Component<Props, State> {

    handleItemClick = (event: React.MouseEvent<HTMLElement>, {name}: any) => {
        this.props.onNavItemChanged(name);
    };


    render() {
        const {activeItem} = this.props;
        const navItems = ['home', 'school', 'teacher', 'student', 'subject'];
        const navColor = 'violet';

        return (
            <header className='Header'>
                <Menu inverted>
                    {navItems.map(item => (
                        <Link to={`/${item}`}>
                            <Menu.Item
                                name={item}
                                active={activeItem === item}
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
