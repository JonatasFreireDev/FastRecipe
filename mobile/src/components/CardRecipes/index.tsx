import React from 'react';

import * as S from './styles';

import Stars from '../Stars';
import StarIn from '../../assets/StarIn.png';

interface IPropsCarRecipes {
  recipe: {
    id: number;
    name: string;
    orner: string;
    stars: number;
    isFavorite?: boolean;
    img: string;
  };
}

const CardRecipes: React.FC<IPropsCarRecipes> = ({ recipe }) => {
  return (
    <S.Container
      style={{
        shadowColor: '#000',
        shadowOffset: {
          width: 0,
          height: 2,
        },
        shadowOpacity: 0.25,
        shadowRadius: 3.84,

        elevation: 5,
      }}
    >
      <S.Img source={{ uri: recipe.img }} />
      <S.Data>
        {recipe.isFavorite ? <S.Favorite source={StarIn} /> : null}
        <S.RecipeName>{recipe.name}</S.RecipeName>
        <Stars stars={recipe.stars} />
        <S.Text>{`Por: \n ${recipe.orner}`}</S.Text>
      </S.Data>
    </S.Container>
  );
};

export default CardRecipes;
