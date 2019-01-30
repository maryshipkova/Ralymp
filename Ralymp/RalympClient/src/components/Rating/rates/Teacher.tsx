import React, {Component} from 'react'
import {ITeacher} from "../../../models/Teacher";

type Props = { teachers: ITeacher[] };
type State = {};
export default class Teacher extends Component<Props, State> {
    render() {
        const {teachers} = this.props;
        return (<ul>
            {teachers.map((teacher: ITeacher) =>
                <li key={teacher.teacherName}>
                    {teacher.teacherName + '  ' + teacher.schoolTitle}
                </li>
            )}
        </ul>);
    }
}

