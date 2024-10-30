import React from 'react'
import Book from '../Book/Book'

interface Props  {}

const CardList: React.FC<Props> = (props: Props) : JSX.Element => {
  return (
    <div>
        <Book BookTitle='Strzygieł' Author='Donna Tartt' Rating={10} />
        <Book BookTitle='Stoner' Author='John Williams' Rating={7}/>
        <Book BookTitle='Ostrze' Author='Joe Abercrombie' Rating={8}/>

    </div>
  )
}

export default CardList

